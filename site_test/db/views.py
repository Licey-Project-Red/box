from django.shortcuts import render
from django.http import HttpResponse
from django.views.decorators.csrf import csrf_exempt
import json
import sqlite3


def get_sqlite():
    conn = sqlite3.connect('D:\\programming\\olimpiads\\predprof\\box\\site_test\\data.sqlite3', check_same_thread = False)
    conn.row_factory = sqlite3.Row
    cursor = conn.cursor()
    rows = cursor.execute('''SELECT * from db_db''').fetchall()
    conn.commit()
    conn.close()

    return json.dumps([dict(ix) for ix in rows])

@csrf_exempt
def index(request):
    if request.is_ajax():
        data = get_sqlite()
        return HttpResponse(data)
    return render(request, 'db/main.html')

@csrf_exempt
def chart(request):
    if request.is_ajax():
        data = get_sqlite()
        return HttpResponse(data)
    return render(request, 'db/chart.html')