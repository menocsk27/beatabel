# Generated by Django 2.2.1 on 2019-05-27 10:48

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('main_app', '0003_auto_20190527_1242'),
    ]

    operations = [
        migrations.AlterField(
            model_name='song',
            name='path',
            field=models.FilePathField(path='D:\\Projects\\Django\\BeatabelAPI\\songs'),
        ),
    ]
