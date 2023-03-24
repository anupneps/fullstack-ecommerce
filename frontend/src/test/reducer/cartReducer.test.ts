import { add, decrement, emptyCart, increment, remove } from "../../redux/reducers/cartReducer"
import { createStore } from "../../redux/store"
import { StoreInterface } from "../../types/StoreInterface"
import { testProductData } from "../test-data/productTestData"

let store : StoreInterface

beforeEach(()=>{
    store = createStore()
})

describe("Testing actions from cart reducer", () => {
    test("testing initial state of cart", ()=>{
        expect(store.getState().cartReducer.cart.length).toBe(0)
    })
    test("testing the add action from cartReducer", ()=>{
        store.dispatch(add(testProductData[0]))
        expect(store.getState().cartReducer.cart.length).toBe(1)
        expect(store.getState().cartReducer.cart[0].quantity).toBe(1)
        expect(store.getState().cartReducer.cart[0].subTotal).toBeGreaterThanOrEqual(0)
    })
    test("testing the add action from cartReducer if same item is added twice", ()=>{
        store.dispatch(add(testProductData[0]))
        store.dispatch(add(testProductData[0]))
        expect(store.getState().cartReducer.cart.length).toBe(1)
        expect(store.getState().cartReducer.cart[0].quantity).toBe(2)
    })
    test("testing remove action from cartReducer", ()=>{
        store.dispatch(add(testProductData[0]))
        const cartLength = store.getState().cartReducer.cart.length
        store.dispatch(remove(testProductData[0]))
        expect(store.getState().cartReducer.cart.length).toBe(cartLength-1)
    })
    test("testing increment action from cartReducer", ()=>{
        store.dispatch(add(testProductData[0]))
        store.dispatch(increment(testProductData[0]))
        store.dispatch(increment(testProductData[0]))
        expect(store.getState().cartReducer.cart[0].quantity).toBe(3)
    })
    test("testing decrement action from cartReducer", ()=>{
        store.dispatch(add(testProductData[0]))
        store.dispatch(decrement(testProductData[0]))
        store.dispatch(decrement(testProductData[0]))
        expect(store.getState().cartReducer.cart[0].quantity).toBe(1)
    })
    test("testing emptyCart action from cartReducer", ()=>{
        store.dispatch(add(testProductData[0]))
        store.dispatch(emptyCart(testProductData[0]))
        expect(store.getState().cartReducer.cart.length).toBe(0)
    })
})

export {}