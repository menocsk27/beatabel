import os
import base64
from pydub import AudioSegment
import librosa


def getTimestamps(source, mode):
    input_file = source
    y, sr = librosa.load(input_file)

    tempo, beat_frames = librosa.beat.beat_track(y=y, sr=sr)

    # print('Estimated tempo: {:.2f} beats per minute'.format(tempo))
    # 4. Convert the frame indices of beat events into timestamps
    beat_times = librosa.frames_to_time(beat_frames, sr=sr)
    song_duration = librosa.get_duration(y=y, sr=sr)
    if mode == "1":
        return tempo, song_duration
    else:
        return beat_times, song_duration

def convertToOgg(source):
    sourceExt = source.rsplit(".", 1)[1]
    oggFile = source.rsplit(".", 1)[0]+".ogg"
    oggB64 = ""
    if sourceExt == "mp3":
        AudioSegment.from_mp3(source).export(oggFile, format="ogg")
    elif sourceExt == "wav":
        AudioSegment.from_wav(source).export(oggFile, format="ogg")
    try:
        with open(oggFile, "rb") as f1:
            oggB64 = str(base64.b64encode(f1.read()))[2:-1]
            f1.close()
            os.remove(oggFile)
    except Exception as e:
        print(str(e))
    return oggB64
    pass