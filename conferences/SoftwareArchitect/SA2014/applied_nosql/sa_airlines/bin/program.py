import mongoengine

import core.data.load_data
from core.data.models import *


def register_connection():
    mongoengine.register_connection(
        'default',
        'sa_flight_db',
        host='mongodb://localhost:27017/'
    )


def register_new_user():
    name = input('Enter your full name: ')

    if not name:
        print("cancelled")
        return

    c = Customer()
    c.first_name = name.split(' ')[0]
    c.last_name = name.split(' ')[1]
    c.address = Address()
    c.address.street = '123 main street'
    c.address.city = 'Portland'
    c.address.state = 'OR'
    c.address.postal_code = '97123'
    c.address.country = 'USA'

    c.save()
    print("We just created: {0}".format(c.to_json()))


def book_flight():
    print("Booking a flight...")

    loc = input('What location are you starting from? ')

    if not loc:
        print("cancelled")
        return

    flights = Flight.objects(start_city=loc)

    for i, f in enumerate(flights):
        print("{3}. {0}: {1} -> {2}".format(f.number, f.start_city, f.end_city, i+1))

    num = input("Which flight do you want? ")
    index = int(num)-1

    f = flights[index]
    f.passengers.append(Customer.objects().first())
    f.save()



def check_flight_status():
    pass


def get_bad_flight():
    f = Flight.objects(number='DL123').first()
    print("Bad flight (which is {1}): {0}".format(f.to_json(), type(f)))


def main():
    register_connection()
    core.data.load_data.load_all_flight_data()

    register_new_user()
    book_flight()
    check_flight_status()
    get_bad_flight()


if __name__ == '__main__':
    main()

