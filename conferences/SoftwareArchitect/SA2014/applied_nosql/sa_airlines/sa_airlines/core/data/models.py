import datetime
import mongoengine
from mongoengine import StringField, BooleanField, ListField, DateTimeField, FloatField, ReferenceField, EmbeddedDocumentField


class Customer(mongoengine.Document):
    pass


class Flight(mongoengine.Document):
    title = StringField(required=True)
    isbn = StringField(required=True)
    author_name = StringField(required=True, default=datetime.datetime.now)
    popular_today = BooleanField(required=True, default=False)
    reviews = ListField(EmbeddedDocumentField('BookReview'))
    published = DateTimeField()
    author = ReferenceField('Author')

    meta = dict(collection='Book',
                index_background=True,
                indexes=[{'fields': ['title'], 'name': 'jays_index'}])


class Airline(mongoengine.Document):
    pass


class Trip(mongoengine.Document):
    pass


class Connection(mongoengine.EmbeddedDocument):
    pass