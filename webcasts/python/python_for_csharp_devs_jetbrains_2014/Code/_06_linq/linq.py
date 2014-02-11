from _04_Anon.anonobject import AnonObject


class Person:
    def __init__(self, name, age, hobby):
        self.hobby = hobby
        self.age = age
        self.name = name

    def __repr__(self):
        return "{0} is {1} and likes {2}".format(self.name, self.age, self.hobby)

p1 = Person("Michael", 40, "Biking")
print(p1.__dict__)

people = [
    Person("Michael", 40, "Biking"),
    Person("Jeff", 50, "Biking"),
    Person("Sarah", 30, "Running"),
    Person("Tony", 24, "Jogging"),
    Person("Zoe", 12, "TV")
]

bikers = [
    AnonObject(Name=p.name, PastTime=p.hobby)
    for p in people
    if p.hobby == "Biking"
]
bikers.sort(key=lambda p: p.Name)

for b in bikers:
    print(b)