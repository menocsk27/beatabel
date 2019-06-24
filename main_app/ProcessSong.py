from pydub import AudioSegment

def get_song_metadata(path):
    song = AudioSegment.from_mp3(path)
    duration = song.duration_seconds
    return duration

def get_song_metadata_file(file):
    song = AudioSegment.from_file(file, "mp3")
    duration = song.duration_seconds
    return duration