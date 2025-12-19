export interface OrderItem {
    productId: number
    productName: string
    price: number
    quantity: number
    stockQuantity: number
    note?: string
}

export interface Order {
    paymentMethod: number
    items: OrderItem[]
}
