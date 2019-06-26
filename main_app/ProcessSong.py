import aubio
import numpy as np

def test(source):
    src = aubio.source(source)
    return(src.uri, src.duration)