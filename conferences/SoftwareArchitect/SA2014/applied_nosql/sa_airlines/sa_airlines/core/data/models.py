import mongoengine
from mongoengine import StringField, ListField, EmbeddedDocumentField, IntField, ReferenceField


class Address(mongoengine.EmbeddedDocument):
    street = StringField(required=True)
    city = StringField(required=True)
    state = StringField(required=True)
    country = StringField(required=True)
    postal_code = StringField(required=True)


class Customer(mongoengine.Document):
    first_name = StringField(required=True)
    last_name = StringField(required=True)
    address = EmbeddedDocumentField('Address')

    meta = dict(collection='Customer')


class Airline(mongoengine.Document):
    name = StringField(required=True)

    meta = dict(collection='Airline')


class Flight(mongoengine.Document):
    number = StringField(required=True)
    start_city = StringField(required=True)
    end_city = StringField(required=True)
    connections = ListField(EmbeddedDocumentField('Connection'))
    passengers = ListField(ReferenceField(Customer))
    delay_in_minutes = IntField(required=True, default=0)
    airline = ReferenceField(Airline, reverse_delete_rule=mongoengine.CASCADE)

    meta = dict(collection='Flight')  # ,
    # index_background=True,
    # indexes=['fields': ['title'], 'name': 'jays_index'}])


class Trip(mongoengine.Document):
    flights = ListField(StringField)

    meta = dict(collection='Trip')


class Connection(mongoengine.EmbeddedDocument):
    flight_number = StringField()

    meta = dict(collection='Connection')

