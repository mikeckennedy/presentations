

def get_special_numbers(limit, test):
    nums = []
    for n in range(limit):
        if not test or test(n):
            nums.append(n)
    return nums

def evens(n):
    return n %2 ==0

for n in get_special_numbers(10, lambda n: n%3==0):
    print(n, end=',')