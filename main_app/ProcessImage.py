import cv2
import base64
import numpy as np

## For testing purposes, coverting image to grayscale
def colorToGray(b64_string):
    input_image = np.fromstring(base64.b64decode(b64_string), np.uint8)
    img = cv2.imdecode(input_image, cv2.IMREAD_GRAYSCALE)
    return encode(img)

## Encode image into base64
def encode(img):
    output_image = cv2.imencode('.jpg', img)[1].tostring()
    tmpOutputEncoded = base64.b64encode(output_image)
    outputImage = str(tmpOutputEncoded).replace("'", "")[1:]
    return outputImage
