import random

# public static List<string> GetDays() {
def get_days():
    # var allDays = new List<string>() {'mon','tues','wed','thurs','fri','sat','sun'};
    all_days = ['mon', 'tues', 'wed', 'thurs', 'fri', 'sat', 'sun']

    # return allDays;
    return all_days

def main():
    days = get_days()

    for day in days:
        report = get_weather_for_day(day)
        print("The weather on {0} is {1}.".format(day, report))


def get_weather_for_day(day):
    reports = ['sunny', 'rainy', 'hot', 'smokey']
    #random.randint(0, len(reports)-1 )
    return random.choice(reports)


if __name__ == "__main__":
    main()
