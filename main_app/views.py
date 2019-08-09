from django.shortcuts import render, HttpResponse
from django.views.decorators.csrf import csrf_exempt
from django.core import serializers
from django.http import JsonResponse
from django.core.files.storage import FileSystemStorage
from .models import Song

import json
import base64
import os

import numpy as np
from . import ProcessSong


def index(request):
    return render(request, "index.html")


## TEMPLATE TO EXPOSE METHODS FOR REST API
## @csrf_exempt
## def methodName(request):
##     pass

@csrf_exempt
def createTimestamps(request):
    songsFolderPath = "songs/"
    # songList =
    if request.method == "GET":
        songs = Song.objects.all()
        data = {"songs": songs}
        return render(request, "timeStampMaker.html", data)
    elif request.method == "POST":
        isSongUpload = False
        isCreateTimestamp = False
        try:
            isSongUpload = request.POST["songUpload"]
            isCreateTimestamp = request.POST["createTimestamp"]
        except Exception as e:
            if e.args[0] == "songUpload":
                isSongUpload = "false"
                isCreateTimestamp = request.POST["createTimestamp"]
            if e.args[0] == "createTimestamp":
                isCreateTimestamp = "false"
                isSongUpload = request.POST["songUpload"]

        if isSongUpload == "true":
            files = request.FILES.getlist("userSongs")
            for file in files:
                # song = Song(name=file.name, path=file)
                # song.save()
                # default_storage.save(songsFolderPath+file.name, file)
                pass
        elif isCreateTimestamp == "true":
            songName = request.POST["songName"]
            timestamps = request.POST["timestamps"]
            timestamps = timestamps.split(",")
            timestamps = [float(t) for t in timestamps]
            songLength = request.POST["songLength"]
            song = Song(name=songName, songLength=songLength, timestamps=np.array(timestamps))
            song.save()
            pass
        return JsonResponse({"Success": True}, status=200)

@csrf_exempt
def getSongs(request):
    if request.method == "GET":
        getDelta = "0"
        if "getDelta" in request.headers:
            getDelta = request.headers["getDelta"]
        songs = Song.objects.all()
        data = serializers.serialize("json", songs, fields=("name", "songLength", "timestamps"))
        data1 = []
        jsonData = json.loads(data)
        for data in jsonData:
            if getDelta == "1":
                data["fields"]["timestamps"] = data["fields"]["timestamps"][1:-1]
                timestamps = data["fields"]["timestamps"]
                timestamps = [float(i) for i in timestamps.split()]
                tmp = timestamps[0]
                timestamps = np.diff(timestamps)
                timestamps = np.append(tmp, timestamps)
                data["fields"]["timestamps"] = str(timestamps)

            data1.append(data["fields"])

        responseObj = {"Songs": data1}
        return JsonResponse(responseObj, status=200)
    return HttpResponse(status=400)

@csrf_exempt
def createAutomatedTimestamps(request):
    timestamps = []
    if request.method == "POST":
        file = request.FILES["song"]
        mode = request.POST["mode"]
        save = request.POST["save"]
        try:
            getDelta = request.POST["getDelta"]
        except Exception as e:
            if e.args[0] == "getDelta":
                getDelta = "0"

        fs = FileSystemStorage()
        filename = fs.save(file.name, file)
        timestamps, song_duration = ProcessSong.getTimestamps("media/"+filename, mode)

        if fs.exists(filename):
            fs.delete(filename)
            pass
        if mode == "1":
            responseObj = {"tempo": timestamps, "SongDuration": song_duration}
        else:
            # tmpTimestamps = re.sub(r'\s+', ' ', "["+str(timestamps)[1:].strip().replace("\n", "")).strip()
            if save == "1":
                song = Song(name=file.name, songLength=song_duration,
                            timestamps=timestamps)
                song.save()
            if getDelta == "1":
                tmp = timestamps[0]
                timestamps = np.diff(timestamps)
                timestamps[0] = tmp
            responseObj = {"timestamps": str(timestamps), "SongDuration": song_duration}

        return JsonResponse(responseObj, status=200)
    return HttpResponse(status=400)

@csrf_exempt
def JSONCreateAutomatedTimestamps(request):
    if request.method == "POST":
        json_data = json.loads(request.body)
        timestamps = []
        if request.method == "POST":
            file = base64.b64decode(json_data["song"]+ "==")
            mode = json_data["mode"]
            save = json_data["save"]
            songName = json_data["songName"]

            try:
                getDelta = json_data["getDelta"]
            except Exception as e:
                if e.args[0] == "getDelta":
                    getDelta = "0"

            try:
                returnOgg = json_data["returnOgg"]
            except Exception as e:
                if e.args[0] == "returnOgg":
                    returnOgg = "0"


            filename = "media/"+songName
            # filename = filename.split(".")[0]+".ogg"
            try:
                with open(filename, "wb+") as f:
                    f.write(file)
                    f.close()
            except Exception as e:
                print(str(e))
            timestamps, song_duration = ProcessSong.getTimestamps(filename, mode)

            if returnOgg == "1":
                try:
                    with open(filename, "rb") as f1:
                        oggFile = ProcessSong.convertToOgg(f1)
                        f1.close()
                except Exception as e:
                    print(str(e))

            os.remove(filename)

            if mode == "1":
                responseObj = {"tempo": timestamps, "SongDuration": song_duration}
            else:
                # tmpTimestamps = re.sub(r'\s+', ' ', "["+str(timestamps)[1:].strip().replace("\n", "")).strip()
                if save == "1":
                    song = Song(name=songName, songLength=song_duration,
                                timestamps=timestamps)
                    song.save()
                if getDelta == "1":
                    tmp = timestamps[0]
                    timestamps = np.diff(timestamps)
                    timestamps[0] = tmp
                responseObj = {"timestamps": str(timestamps), "SongDuration": song_duration}
                if returnOgg == "1":
                    responseObj["oggB64"] = oggFile
                    pass

            return JsonResponse(responseObj, status=200)
        return HttpResponse(status=400)


# @csrf_exempt
# def colorToGray(request):
#     ## A base64 string for an example color image
#     # img_b64 = "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"
#     if request.method == "POST":
#         img_b64 = json.loads(request.body)["image_b64"]
#         if img_b64 != None or img_b64 != "":
#             if(img_b64 != "" or img_b64 != None):
#                 img = ProcessImage.colorToGray(img_b64)
#                 if len(img) != None:
#                     return HttpResponse(img)
#                     # return JsonResponse({"result_image": img})
#                 else:
#                     return HttpResponse(status=400)
#             else:
#                 return HttpResponse(status=400)
#     return HttpResponse(status=400)

