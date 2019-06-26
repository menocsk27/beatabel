from django.db import models
from django.conf import settings

class Song(models.Model):
    name = models.CharField(max_length=256)
    songLength = models.FloatField(default=0.0, null=False)
    timestamps = models.TextField(null=False, default=None)
