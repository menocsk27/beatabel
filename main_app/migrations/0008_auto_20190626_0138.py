# Generated by Django 2.2.1 on 2019-06-25 23:38

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('main_app', '0007_remove_song_path'),
    ]

    operations = [
        migrations.AddField(
            model_name='song',
            name='songLength',
            field=models.FloatField(default=0.0),
        ),
        migrations.AlterField(
            model_name='song',
            name='timestamps',
            field=models.TextField(default=None),
        ),
    ]
