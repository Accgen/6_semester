import telebot
from telebot import types
from selenium import webdriver
from time import sleep

driver = webdriver.Chrome()

bot = telebot.TeleBot("5336357947:AAGjQ7Sxii_RrCN2aS0HUKxOxADM6Jy5miY")


@bot.message_handler(commands=['start'])
def start(message):
    markup = types.ReplyKeyboardMarkup(resize_keyboard= True)
    item1 = types.KeyboardButton('Найти лекарство по названию')
    #item2 = types.KeyboardButton('Найти ближайшую ко мне аптеку')

    markup.add(item1, item2)

    bot.send_message(message.chat.id, 'Привет, {0.first_name}, ты что-то хотел?'.format(message.from_user), reply_markup=markup)


@bot.message_handler(content_types=['text'])
def find_tabletki(message):
    if message.text == 'Найти лекарство по названию':
        bot.send_message(message.chat.id, "Введите название, препарата который ищете")
        bot.register_next_step_handler(message, search)

"""@bot.message_handler(content_types=['text'])
def find_closer_apteka(message):
    if message.text == 'Найти ближайшую ко мне аптеку':
        bot.send_message(message.chat.id, "Данная функция ещё разрабатывается!")
"""

@bot.message_handler(content_types=['text'])
def text(message):
    bot.send_message(message.chat.id, "Что-нибудь ещё?")


def search(message):
    bot.send_message(message.chat.id, "Начинаю поиск")
    tabletki_XPath = "https://tabletka.by/search?request=" + message.text
    driver.get(tabletki_XPath)
    sleep(2)
    tabletki = driver.find_elements_by_xpath('//*[@id="base-select"]/tbody/tr[1]/td[2]/div/div[1]/div/a')
    for i in range(len(tabletki)):
        bot.send_message(message.chat.id, tabletki[i].get_attribute('XPath'))
        if i == 10:
            break


bot.polling()


