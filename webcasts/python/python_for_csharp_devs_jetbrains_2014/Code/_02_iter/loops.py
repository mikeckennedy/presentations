nums = [2, 3, 5, 7, 11, 13, 17, 19]

for index, n in enumerate(nums):
    print(n, end=', ')


class CartItem:
    def __init__(self, name, price):
        self.price = price
        self.name = name

    def __repr__(self):
        return "({0}, ${1})".format(self.name, self.price)


class ShoppingCart:
    def __init__(self):
        self.__items = []

    def add(self, cart_item):
        self.__items.append(cart_item)

    def __iter__(self):
        return self.__items.__iter__()

    @property
    def total_price(self):
        total = 0.0
        for item in self.__items:
            total += item.price

        return total


print()
print()

cart = ShoppingCart()
cart.add(CartItem("CD", 19.99))
cart.add(CartItem("Record", 17.99))

for item in cart:
    print(item)

print("Total price is ${0:,}".format(cart.total_price))

print(dir(cart))