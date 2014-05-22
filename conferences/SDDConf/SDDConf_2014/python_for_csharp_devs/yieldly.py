def fib_nums():
    current, nxt = 0, 1
    while True:
        current,nxt = nxt, nxt+current
        yield current


for n in fib_nums():
    if n > 10000:
        break;
    print(n, end=',')