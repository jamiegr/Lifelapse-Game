import requests
from bs4 import BeautifulSoup
import numpy as np


def get_info(url, obj):
    r = requests.get(url)

    soup = BeautifulSoup(r.content, 'html5lib')
    divs = soup.find("table", {"class": "table table-hover"})
    table = divs.find("tbody").find_all("tr")

    table = np.array(table)
    data = {}

    # for row in table:
    for i in range(table.size - 1):
        row = table[i].find_all("td")
        temp = {
            'var_class': row[0].text.strip(),
            'var_last': row[1].text,
            'var_prev': row[2].text,
            'var_high': row[3].text,
            'var_low': row[4].text
        }
        data[row[0].text.strip()] = temp

    return data[obj]


