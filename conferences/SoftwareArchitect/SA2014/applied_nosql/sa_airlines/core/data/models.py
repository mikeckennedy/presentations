from mongoengine import *


class Address(EmbeddedDocument):
    street = StringField(required=True)
    city = StringField(required=True)
    country = StringField(required=True)
    postal_code = StringField(required=True)


class Customer(Document):
    first_name = StringField(required=True)
    last_name = StringField(required=True)
    address = EmbeddedDocumentField(Address)

    meta = dict(collection='Customers')


class Airline(Document):
    name = StringField(required=True)
    meta = dict(collection='Airlines')


class Connection(EmbeddedDocument):
    flight_number = StringField()
    end_city = StringField()


class Flight(Document):
    number = StringField(required=True)
    start_city = StringField(required=True)
    discount_rate = FloatField()
    end_city = StringField(required=True)
    airline = ReferenceField(Airline)
    delay_in_minutes = IntField()
    passengers = ListField(ReferenceField(Customer))
    connections = ListField(EmbeddedDocumentField(Connection))
    meta = dict(collection='Flights',
                index_background=True,
                indexes=[{'fields': ['number'], 'name': 'find_by_number'}])


class Trip(Document):
    pass


