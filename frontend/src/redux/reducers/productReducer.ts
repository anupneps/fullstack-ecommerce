import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import { AxiosResponse } from "axios";

import axiosInstance from "../../shared/axiosInstance";
import { CreateProduct } from "../../types/createProduct";
import { ModifyProduct, Product } from "../../types/product";

const initialState: Product[] = []

export interface CreateProductWithForm{
    image:File,
    product:CreateProduct
}

export const fetchAllProducts = createAsyncThunk(
    'fetchAllProducts',
    async () => {
        try {
            const jsondata: AxiosResponse<Product[], Product> = await axiosInstance.get('products')
            return jsondata.data
        } catch (error: any) {
            throw new Error(error.message)
        }
    }
)

export const createProduct = createAsyncThunk(
    'createProduct',
    async (product: CreateProduct) => {
        try {
            const jsondata: AxiosResponse<Product, any> = await axiosInstance.post('products', product)
            console.log('success')
            return jsondata.data
        } catch (error: any) {
            console.log(error.message)
            throw new Error(error.message)
        }
    }
)
export const createProductWithForm = createAsyncThunk(
    'createProductWithForm',
    async({
        image, 
        product
    }: CreateProductWithForm)=> {
        try {
            const response = await axiosInstance.post("files/upload", image, {
                headers:{
                    "Content-Type":"multipart/form-data"
                }
            })
            const data = response.data.location
            console.log("location:", data)
            const productResponse = await axiosInstance.post("products", {
                ...product, 
                images:[...product.images, data]
            })
            return productResponse.data
        } catch (error) {
            
        }
    }
)

export const modifyProduct = createAsyncThunk(
    'modifyProduct',
    async ({ updateId, update }: ModifyProduct) => {
        try {
            const jsondata: AxiosResponse<Product, any> = await axiosInstance.put(`products/${updateId}`, update)
            return jsondata.data
        } catch (error: any) {
            throw new Error(error.message)
        }
    }
)

export const deleteAproduct = createAsyncThunk(
    'deleteProduct',
    async (productId: number|undefined) => {
        try {
            const jsondata: AxiosResponse<boolean> = await axiosInstance.delete(`products/${productId}`)
            return jsondata.data
        } catch (error: any) {
            throw new Error(error.message)
        }
    }
)

const productSlice = createSlice({
    name: "productSlice",
    initialState: initialState,
    reducers: {
        sortByName: (state, action: PayloadAction<'asc' | 'desc'>) => {
            if (action.payload === 'asc') {
                state.sort((a, b) => a.title.localeCompare(b.title))
            } else {
                state.sort((a, b) => b.title.localeCompare(a.title))
            }
        },
        sortByPrice: (state, action: PayloadAction<'asc'>) => {
            if (action.payload === 'asc') {
                state.sort((a, b) => (a.price) - (b.price))
            }
        }
    },
    extraReducers: (build) => {
        build.addCase(fetchAllProducts.fulfilled, (state, action) => {
            if (action.payload && "message" in action.payload) {
                return state
            } else if (!action.payload) {
                return state
            }
            return action.payload
        })
            .addCase(fetchAllProducts.rejected, (state, action) => {
                return state
            })
            .addCase(fetchAllProducts.pending, (state, action) => {
                return state
            })
            .addCase(createProduct.fulfilled, (state, action) => {
                if (action.payload) {
                    state.push(action.payload)
                } else {
                    return state
                }
            })
            .addCase(deleteAproduct.fulfilled, (state, action) => {
                if (action.payload === true) {
                    return state
                }
                return { ...state }
            })
            .addCase(modifyProduct.fulfilled, (state, action) => {
                return state.map((product) => {
                    if (product.id === action.payload.id) {
                        return action.payload
                    }
                    return product
                })
            })
            .addCase(createProductWithForm.fulfilled, (state,action)=>{
                if (action.payload) {
                    state.push(action.payload)
                } else {
                    return state
                }
            })
    }
})

const productReducer = productSlice.reducer
export const { sortByName, sortByPrice } = productSlice.actions
export default productReducer


