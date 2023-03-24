import { Users } from "./users"

export interface AuthState {
    user?: Users | null
    isAuthenticated?: boolean
    isSuccess: boolean
    isLoading: boolean
    isError: boolean
    token: string|undefined
}