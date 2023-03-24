import axios from "axios";

const axiosInstance = axios.create({
    baseURL: 'https://orderlyonclick.azurewebsites.net/api/v1/'
})

export default axiosInstance