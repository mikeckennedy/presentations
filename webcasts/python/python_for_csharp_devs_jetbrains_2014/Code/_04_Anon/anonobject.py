class AnonObject(dict):
    __getattr__ = dict.get
    __setattr__ = dict.__setitem__

person = {
    "name": "Michael",
    "age": 40
}

anonPerson = AnonObject(name="Michael", age=40)

print(anonPerson)
print(anonPerson["name"])
print(anonPerson.name)
print(anonPerson.age)