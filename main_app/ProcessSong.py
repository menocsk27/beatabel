import librosa
import os
import numpy as np

def test1(source):
    input_file = source
    y, sr = librosa.load(input_file)

    tempo, beat_frames = librosa.beat.beat_track(y=y, sr=sr)

    # print('Estimated tempo: {:.2f} beats per minute'.format(tempo))
    # 4. Convert the frame indices of beat events into timestamps
    beat_times = librosa.frames_to_time(beat_frames, sr=sr)
    return beat_times
