# https://codegists.com/user/DomNomNom
# https://codegists.com/code/scrape.py-examples/

from bs4 import BeautifulSoup as bs

import urllib.request as request
import urllib.parse as parse
import pprint
import re
import json

# Selects sections of html that we are interested in
def prepare(html):
    soup = bs(html, 'html.parser')

    game = {
        'Name'      : soup.find('div', {'class': 'apphub_AppName'}),
        'Price'     : soup.find('div', {'class': 'game_purchase_Price Price'}),
        'currency'  : soup.find('div', {'class': 'game_purchase_Price Price'}),
        #'rating'    : 0.0
     }

    return game


def cook(game):

    defaults = {
        'Name'     : '',
        'Price'    : 0.0,
        'currency' : '',
        #'rating'   : 0.0
    }

    def processCurrency(currencyTag):
        text = currencyTag.text
        if 'Free to Play' in text:
            return ''
        else:
            return text.strip().split()[0]

    processors = {
        'Name'     : lambda x: x.text.strip(),
        'Price'    : lambda x: x.text.strip().split()[0],
        'currency' : processCurrency,
        #'rating'   : 0.0
    }

    # Runs the processing functions in progessors on the game data.
    # It infers the target type
    def process(game, processors, defaults):
        assert all( gamekey in processors and gamekey in defaults  for gamekey in game )

        newGame = {}
        for key, value in processors.items():
            if type(value) == dict:
                newGame[key] = process(game[key], processors[key], defaults[key])
            elif callable(value):
                try:
                    newValue = processors[key](game[key])
                    defaultType = type(defaults[key])
                    if type(newValue) != defaultType:
                        newValue = defaultType(newValue)
                    newGame[key] = newValue
                except:
                    assert key in defaults, 'default not defined for ' + repr(key)
                    newGame[key] = defaults[key]
            else:
                raise Exception('processors dict contains something unexpected: ' + repr(value))
        return newGame

    return process(game, processors, defaults)



def getHTML(url):

    headers = {
        'User-Agent': 'Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:38.0) Gecko/20100101 Firefox/38.0',
        'Accept-Encoding': "utf-8",
    }

    # request body
    body = {}
    data = parse.urlencode(body)
    req = request.Request(url + '?' + data, headers=headers)

    resp = request.urlopen(req)
    resp = resp.read().decode('utf-8')
    return resp

# Urls are picked here.
# Planning on eventually getting rid of empty entries and only deal with valid entries.
n=10
while n < 220:
    for app in [n]:
        try:
            data = {}
            url = 'http://store.steampowered.com/app/' + str(app)
            newGame = cook(prepare(getHTML(url)))
            tempPrice = newGame['currency']
            tempPrice = re.sub("[\$]", "", tempPrice, 0, 0)

            data['Name'] = newGame['Name']
            data['Price'] = float(tempPrice)
            data['Vendor'] = 'Steam'
            data['ProductUrl'] = url
            data['Platform'] = 'PC'

            data_json = json.dumps(data)
            headers = {'Content-type': 'application/json', 'Content-Length': '120'}
            response = requests.post('http://localhost:51102/api/game', data=data_json, headers=headers)
        except:
            print("game not found")
    n = n + 1
