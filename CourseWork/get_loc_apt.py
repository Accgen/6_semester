from geopy import Yandex
while(True):
    place = input("Введи адрес аптеки: ") #Сюда адрес аптеки
    location = Yandex(api_key='0ef27e34-3ede-402a-95f2-fee33edd3e6f').geocode(place)
    lat = location.latitude
    lon = location.longitude
    print(f"{location.address}" + "\nCoordinates:" + f"{lat}", f"{lon}")
