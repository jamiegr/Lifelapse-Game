from flask import Flask, request, jsonify
import os
import scraper

app = Flask(__name__)
app_root = os.path.dirname(os.path.abspath(__file__))


@app.route('/scrape-stats', methods=['POST'])
def test():
    if request.method == 'POST':
        link = request.form['link']
        type = request.form['type']
        data = scraper.get_info(link, type)
        return jsonify(data)


if __name__ == '__main__':
    app.run(host='0.0.0.0', debug=True)

