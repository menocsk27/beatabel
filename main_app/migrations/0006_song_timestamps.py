# Generated by Django 2.2.1 on 2019-06-25 10:13

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('main_app', '0005_auto_20190527_1252'),
    ]

    operations = [
        migrations.AddField(
            model_name='song',
            name='timestamps',
            field=models.TextField(default=None, null=True),
        ),
    ]