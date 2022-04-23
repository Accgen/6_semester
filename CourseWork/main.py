import telebot
import requests
from bs4 import  BeautifulSoup
from telebot import types


bot = telebot.TeleBot("5336357947:AAGjQ7Sxii_RrCN2aS0HUKxOxADM6Jy5miY")


@bot.message_handler(commands=['start'])
def start(message):
    markup = types.ReplyKeyboardMarkup(resize_keyboard= True)
    item1 = types.KeyboardButton('Найти лекарство по названию')
    item2 = types.KeyboardButton('Найти ближайшую ко мне аптеку')

    markup.add(item1, item2)

    bot.send_message(message.chat.id, 'Привет, {0.first_name}, ты что-то хотел?'.format(message.from_user), reply_markup=markup)


@bot.message_handler(content_types=['text'])
def find_tabletki(message):
    if message.text == 'Найти лекарство по названию':
        bot.send_message(message.chat.id, "Введите название, препарата который ищете")
        bot.register_next_step_handler(message, search)
    if message.text == 'Найти ближайшую ко мне аптеку':
        bot.send_message(message.chat.id, "Введите адрес ваш адрес пожалуйста")
        bot.register_next_step_handler(message, find_pharmacy)

#ПОИСК ЛЕКАРСТВ--------------
def search(message):
    bot.send_message(message.chat.id, "Начинаю поиск лекарства")

    url = 'https://tabletka.by'

    find_url = 'https://tabletka.by/search?request=' + message.text
    response = requests.get(find_url)
    soup = BeautifulSoup(response.text, 'lxml')

    save_message = message.text

    internalLinks = [
        a.get('href')
        for a in soup.find_all('a')
        if a.get('href') and a.get('href').startswith('/result') and a.get_text().startswith(f"{save_message.capitalize()}")]


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
def find_pharmacy(message):
    bot.send_message(message.chat.id, "Воу воу воу не спеши дружок , я ещё не готов , но адресок я твой запишу и украинска бимба скоро вылетить!")
    bot.send_message(message.chat.id, 'А пока что {0.first_name} иди погуляй'.format(message.from_user))

bot.polling(none_stop= True)


