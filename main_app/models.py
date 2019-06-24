from django.db import models
from django.conf import settings

class Song(models.Model):
    name = models.CharField(max_length=256)
    path = models.FileField(upload_to=settings.SONGS_PATH)
