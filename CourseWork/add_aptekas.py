import pandas as pd


dict_adr = {"Name" : ["Ремедика","Витафарм1","Витафарм2","Фармация"],
            "Latitude" : [52.0969326, 52.09719415, 52.09884979, 52.09246070],
            "Longitude" : [23.7526257, 23.763297326, 23.75645416, 23.766562928517423],
            "Address" : ["Московская ул., 253","просп. Республики, 1","Московская ул., 326","ул. Богданчука, 126"],
            "Telephone" : ["+375 16 253-11-07","+375 16 228-13-57","+375 16 259-30-98","+375 16 235-51-06"],
            "Work-time" : ["09:00 – 21:00","08:00 – 20:00","08:00 – 22:00","09:00 – 20:00"]}

df = pd.DataFrame(dict_adr)
df.to_csv("apt_info.csv")






