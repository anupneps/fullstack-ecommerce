import {createAsyncThunk, createSlice} from '@reduxjs/toolkit'
import {AxiosResponse} from 'axios'

import axiosInstance from '../../shared/axiosInstance'
import {Category} from '../../types/category'

export const fetchAllCategories= createAsyncThunk(
    'fetchAllCategories',
    async () => {
        try {
            const jsondata: AxiosResponse<Category[], Category> = await axiosInstance.get('categories')
            return jsondata.data
          
        } catch (error: any) {
            throw new Error(error.message)
        }
    }
)

const initialState:Category[]=[]

const categorySlice = createSlice({
    name: "categorySlice",
    initialState: initialState,
    reducers: {
        
    },
    extraReducers: (build) => {
        build.addCase(fetchAllCategories.fulfilled,(state,action)=>{
            if (action.payload && "message" in action.payload) {
                return state
            } else if (!action.payload) {
                return state
            }
            return action.payload
        })
    }
})

const categoryReducers = categorySlice.reducer
export default categoryReducers