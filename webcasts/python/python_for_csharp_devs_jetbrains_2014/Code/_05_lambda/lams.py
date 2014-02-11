
def get_numbers(limit, predicate):
    for n in range(0, limit):
        if predicate(n):
            yield n

# def divide_by_11(n):
#     return n % 11 == 0

output = list(get_numbers(40, lambda n: n % 10 == 0))

print(output)

