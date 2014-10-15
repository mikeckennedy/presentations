from core.data.models import Airline, Flight, Connection


def load_all_flight_data():
    print("Loading all data...")

    load_airlines()
    load_flights()


def load_flights():
    print("Loading flight data... ", end="")

    #TODO: Bail out if the flights are already loaded.

    # flights = []
    #
    # f = Flight()
    # f.number = "UA1243"
    # f.airline = Airline.objects(name='United').first()
    # f.start_city = "Portland, OR"
    # f.end_city = "Houston, TX"
    # f.delay_in_minutes = 30
    # c = Connection()
    # c.flight_number = "UA2733"
    # f.connections.append(c)
    # flights.append(f)
    #
    # f = Flight()
    # f.airline = Airline.objects(name='United').first()
    # f.number = "UA2733"
    # f.start_city = "Houston, TX"
    # f.end_city = "London, UK"
    # f.delay_in_minutes = 0
    # flights.append(f)
    #
    # f = Flight()
    # f.airline = Airline.objects(name='United').first()
    # f.number = "UA2713"
    # f.start_city = "Portland, OR"
    # f.end_city = "Seattle, WA"
    # f.delay_in_minutes = 10
    # flights.append(f)
    #
    # f = Flight()
    # f.number = "UA2753"
    # f.airline = Airline.objects(name='United').first()
    # f.start_city = "Seattle, WA"
    # f.end_city = "Chicago, IL"
    # f.delay_in_minutes = 200
    # c = Connection()
    # c.flight_number = "DL453"
    # f.connections.append(c)
    # c = Connection()
    # c.flight_number = "SW200"
    # f.connections.append(c)
    # flights.append(f)
    #
    # f = Flight()
    # f.number = "DL453"
    # f.airline = Airline.objects(name='Delta').first()
    # f.start_city = "Seattle, WA"
    # f.end_city = "Chicago, IL"
    # f.delay_in_minutes = 300
    # flights.append(f)
    #
    # f = Flight()
    # f.number = "SW200"
    # f.airline = Airline.objects(name='Southwest').first()
    # f.start_city = "Seattle, WA"
    # f.end_city = "Miami, FL"
    # f.delay_in_minutes = 12
    # flights.append(f)
    #
    # f = Flight()
    # f.number = "DL55"
    # f.airline = Airline.objects(name='Delta').first()
    # f.start_city = "Chicago, IL"
    # f.end_city = "London, UK"
    # f.delay_in_minutes = 350
    # flights.append(f)

    # TODO: Save flights to DB
    print("done (with pending TODO)")


def load_airlines():
    print("Loading airline data... ", end="")

    #TODO: Bail out if the flights are already loaded.

    airlines = []

    # a = Airline()
    # a.name = "United"
    # airlines.append(a)
    #
    # a = Airline()
    # a.name = "Southwest"
    # airlines.append(a)
    #
    # a = Airline()
    # a.name = "Delta"
    # airlines.append(a)
    #
    # a = Airline()
    # a.name = "Virgin"
    # airlines.append(a)
    #
    # a = Airline()
    # a.name = "Air France"
    # airlines.append(a)

    # TODO: Save flights to DB

    print("done (with pending TODO)")
