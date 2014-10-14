def fibinnoci():
    current = 0
    nxt = 1

    while True:
        current, nxt = nxt, current + nxt
       # print("Generating" + str(current))
        yield current


for n in fibinnoci():
    if n > 200:
        break;

    print(n, end=', ')

