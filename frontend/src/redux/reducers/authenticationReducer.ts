import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import { AxiosResponse } from 'axios'

import axiosInstance from '../../shared/axiosInstance'
import { AuthState } from '../../types/authorization'
import { Users } from '../../types/users'

const initialState: AuthState = {
    isSuccess: false,
    isLoading: false,
    isError: false,
    isAuthenticated: false,
    token:undefined,
    user: {
        id: null,
        firstName:'',
        lastName:'',
        userName:'',
        email: '',
        password: '',
        name: '',
        role: '',
        avatar: '',
        access_token: ''
    }
}

export const createUser = createAsyncThunk(
    "createUser",
    async (user: Users) => {
        try {
            const response: AxiosResponse<Users, Error> = await axiosInstance.post("users", user)
            return response.data
        } catch (error) {
            console.log(error)
        }
    }
)

export const autheticateUser = createAsyncThunk(
    "authenticateUser",
    async (user: Users) => {
        try {
            const response: AxiosResponse<string, null> = await axiosInstance.post("authentication", user)
            const tokenReceived = response.data 
            console.log("Login Successful")
        
            const sessionInfo: AxiosResponse<Users> = await axiosInstance.get('authentication/profile',
                {
                    headers:
                        { Authorization: `Bearer ${tokenReceived}` }
                })
            return {token:tokenReceived, user:sessionInfo.data}
        } catch (error) {
            console.log(error)
        }
    }
)

const authenticationSlice = createSlice({
    name: 'authenciationSlice',
    initialState: initialState,
    reducers: {
        logout(state) {
            state.isAuthenticated = false
            state.token = undefined;
            localStorage.clear()
        }

    }, extraReducers: (build) => {
        build.addCase(autheticateUser.pending, (state, action) => {
            state.isLoading = true
        })
        build.addCase(autheticateUser.fulfilled, (state, action) => {
            state.isSuccess = true
            state.isLoading = false
            state.isAuthenticated = true
            state.token = action.payload?.token
            state.user = action.payload?.user
        })
        build.addCase(autheticateUser.rejected, (state, action) => {
            state.isError = true
        })
        // SignUp extrareducers
        build.addCase(createUser.pending, (state, action) => {
            state.isLoading = true
        })
        build.addCase(createUser.fulfilled, (state, action) => {
            state.isLoading = false
            state.isSuccess = true
        })
        build.addCase(createUser.rejected, (state, action) => {
            state.isError = true
        })
    },
})

const authenticationReducer = authenticationSlice.reducer
export const { logout } = authenticationSlice.actions
export default authenticationReducer
