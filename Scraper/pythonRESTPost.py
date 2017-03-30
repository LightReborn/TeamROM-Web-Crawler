import requests
import json

data = {"Name":"Fallout 3","ReviewRating":"91","Price":"9.99","Vendor":"Steam","ProductUrl":"http://store.steampowered.com/app/22300/","Genre":"RPG","Platform":"Windows"}
data_json = json.dumps(data)
headers = {'Content-type': 'application/json', 'Content-Length': '120'}

#Make sure to change the url to the appropriate port if you build everything on your own device. The port may differ/change.
response = requests.post('http://localhost:51102/api/game', data=data_json, headers=headers)
