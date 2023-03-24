import { createSlice} from '@reduxjs/toolkit'
import { Product } from '../../types/product'

export interface CartState {
    cart:Product[]
}

const initialState:CartState= {
    cart:[]
}

const cartSlice = createSlice({
    name: 'cartSlice',
    initialState:initialState,
    reducers:{
        add (state, action) {
            const productInCart = state.cart.find(product=>product.id === action.payload.id)
            if(productInCart && productInCart.quantity){
               productInCart.quantity +=1
               productInCart.subTotal= productInCart.price * productInCart.quantity
               return
            }
             state.cart.push({...action.payload, quantity:1, subTotal:action.payload.price})
        },
        remove (state, action) {
        state.cart = state.cart.filter(product => product.id!== action.payload.id)
        },
        increment (state, action){
            const productToIncremenet = state.cart.find(product => product.id === action.payload.id)
            if(productToIncremenet && productToIncremenet.quantity){
                productToIncremenet.quantity = productToIncremenet.quantity+1
                productToIncremenet.subTotal= productToIncremenet.price * productToIncremenet.quantity
            }
        },
        decrement (state, action){
            const productToDecrement = state.cart.find(product => product.id === action.payload.id)
            if(productToDecrement && productToDecrement.quantity && productToDecrement.quantity>1){
                productToDecrement.quantity = productToDecrement.quantity-1
                productToDecrement.subTotal= productToDecrement.price * productToDecrement.quantity
            }
            return
        },
        emptyCart(state, action){
           state.cart =[]
        }
    }
})

const cartReducer =  cartSlice.reducer
export const {add, remove, increment, decrement, emptyCart} = cartSlice.actions;
export default cartReducer;