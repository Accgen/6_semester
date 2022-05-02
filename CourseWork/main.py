import telebot
import requests
from bs4 import  BeautifulSoup
from telebot import types
from geopy import Yandex
from geopy.distance import geodesic
import pandas as pd
from pandas import read_csv


bot = telebot.TeleBot("5336357947:AAGjQ7Sxii_RrCN2aS0HUKxOxADM6Jy5miY")


@bot.message_handler(commands=['start'])
def start(message):
    markup = types.ReplyKeyboardMarkup(resize_keyboard= True)
    item1 = types.KeyboardButton('Найти лекарство по названию')
    item2 = types.KeyboardButton('Найти ближайшую ко мне аптеку')

    markup.add(item1, item2)

    bot.send_message(message.chat.id, 'Привет, {0.first_name}, ты что-то хотел?'.format(message.from_user), reply_markup=markup)

@bot.message_handler(content_types=['text'])
def find(message):
    if message.text == 'Найти лекарство по названию':
        bot.send_message(message.chat.id, "Введите название, препарата который ищете")
        bot.register_next_step_handler(message, search)
    if message.text == 'Найти ближайшую ко мне аптеку':
        bot.send_message(message.chat.id, "Введите адрес ваш адрес пожалуйста, \nПример: 'Московская 267/1, Брест' ")
        bot.register_next_step_handler(message, find_apteka)

#ПОИСК ЛЕКАРСТВ--------------
def search(message):
    bot.send_message(message.chat.id, "Начинаю поиск лекарства")

    url = 'https://tabletka.by'

    find_url = 'https://tabletka.by/search?request=' + message.text
    response = requests.get(find_url)
    soup = BeautifulSoup(response.text, 'lxml')

    save_message = message.text
    capitalizeMessage = save_message.capitalize()
    replacestr = capitalizeMessage.replace(" ", "")

    internalLinks = [
        a.get('href')
        for a in soup.find_all('a')
        if a.get('href') and a.get('href').startswith('/result') and a.get_text().startswith(f"{replacestr}")]


    print(replacestr)
    sorted_links = []
    for j in internalLinks:
        if j not in sorted_links:
            sorted_links.append(j)


    if sorted_links == []:
        bot.send_message(message.chat.id, "По вашему запросу ничего не найдено")

    for i in range(len(sorted_links)):
        result = sorted_links[i]
        new_url = url + result
        bot.send_message(message.chat.id, new_url)
        if i == 9:
            break


#ПОИСК АПТЕКИ----------------------
def find_apteka(message):
    place = message.text
    location = Yandex(api_key='0ef27e34-3ede-402a-95f2-fee33edd3e6f').geocode(place)

    lat = location.latitude
    lon = location.longitude

    latitude_place = float(lat)
    longitude_place = float(lon)


    path = "D:/6_semester/CourseWork/apt_info.csv"
    df1 = read_csv(path, delimiter=",", header=0)


    apt_coords = []
    loc_dist = {}
    for i,j,k in zip(df1['Latitude'],df1['Longitude'],df1['Name']):
        temp_apteka = (i,j)
        apt_coords.append(temp_apteka)
        loc_dist.update({f"{k}": f"{temp_apteka}"})


    user = (f"{latitude_place}" ,f"{longitude_place}")

    distance_m = []
    for i in range(len(apt_coords)):
        distance_m.append(geodesic(user, apt_coords[i]).meters)

    count = 0

    for key in loc_dist:
        loc_dist[key] = distance_m[count]
        count += 1

    # print("----------")
    # print(loc_dist)
    # print("----------")

    min_dist = min(loc_dist.values())
    # print(min_dist)
    # print(min_dist in loc_dist.values())
    #print(list(loc_dist.keys())[list(loc_dist.values()).index(min_dist)])

    apteka_name = list(loc_dist.keys())[list(loc_dist.values()).index(min_dist)]
    for i,j,k,z in zip(df1['Name'],df1['Address'],df1['Telephone'],df1['Work-time']):
        if apteka_name == i:
            print(i,j,k,z)
            bot.send_message(message.chat.id, f"{i}" + "\nАдрес: " + f"{j}" + "\nТелефон: " + f"{k}" + "\nВремя работы: " + f"{z}")




bot.polling(none_stop= True)




