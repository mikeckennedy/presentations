bikes = [
    dict(name='fsr', type='mountain', gears=21, suspension=True),
    dict(name='giant', type='mountain', gears=28, suspension=True),
    dict(name='fast', type='road', gears=28, suspension=False),
    dict(name='cruiser', type='beach', gears=1, suspension=False)
]

mountain_bikes = (
    b['name'] # select
    for b in bikes # from b in bikes
    if b['type'] == 'mountain' # where b...
)

print(mountain_bikes)

for b in mountain_bikes:
    print(b)