from sa_airlines.core.data.models import Flight


class DbServices:
    @staticmethod
    def find_all_flights_for_location(location):
        query = Flight \
            .objects(start_city=location) \
            .order_by("end_city")

        return list(query)

    @staticmethod
    def find_flight_by_number(num):
        flight = Flight.objects(number=num).first()

        return flight

    @staticmethod
    def delayed_flights():
        flight = Flight.objects(delay_in_minutes__gt=0)

        return flight
