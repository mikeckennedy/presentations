class CartItem:
    def __init__(self, name, price):
        self.price = price
        self.name = name


class ShoppingCart:
    def __init__(self):
        self.items = []

    def add_item(self, item):
        self.items.append(item)

    def __iter__(self):
        return self.items.__iter__()

    @property
    def total_price(self):
        total = 0
        for item in cart:
            total += item.price
        return total


cart = ShoppingCart()
cart.add_item(CartItem('Telsa', 120000))
cart.add_item(CartItem('Lotus', 78000))

total = 0
for item in cart:
    total += item.price

print("Total is ${0:,}".format(total))
print("Total is ${0:,}".format(cart.total_price))