from pydub import AudioSegment
import librosa
import base64
import os

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
    oggFile = source.split(".")[0]+".ogg"
    oggB64 = ""
    AudioSegment.from_mp3(source).export(oggFile, format="ogg")
    try:
        with open(source, "rb") as f1:
            oggB64 = str(base64.b64encode(f1.read()))
            f1.close()
            os.remove(oggFile)
    except Exception as e:
        print(str(e))
    return oggB64