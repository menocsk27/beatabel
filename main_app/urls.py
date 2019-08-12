from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    # url(r'^colorToGray/$', views.colorToGray),
    url(r'^createTimestamps/$', views.createTimestamps),
    url(r'^getSongs/$', views.getSongs),
    url(r'^createAutomatedTimestamps/$', views.createAutomatedTimestamps),
    url(r'^JSONCreateAutomatedTimestamps/$', views.JSONCreateAutomatedTimestamps),
    url(r'^convertToOgg/$', views.convertToOGG)
]