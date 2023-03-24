import {Checkbox, FormControlLabel, Stack, TextField } from '@mui/material'
import Button from '@mui/material/Button'
import Grid from '@mui/material/Grid'
import Typography from '@mui/material/Typography'
import { useEffect} from 'react'
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'
import { Divider } from '@mui/material';
import { Link, useNavigate } from 'react-router-dom'
import * as yup from "yup";
import { useForm, SubmitHandler } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup'

import { autheticateUser } from '../redux/reducers/authenticationReducer'
import { Users } from '../types/users'

const schema = yup.object({
    email: yup.string().email().required("Email is required !"),
    password: yup.string().min(8).max(32).required("Password is required !"),
  }).required();

const Login = () => {
    const{register, handleSubmit, formState:{errors}} = useForm<Users>({
        resolver:yupResolver(schema)
    })
    let navigate = useNavigate();
    const routeChange = () => {
        navigate('/')
    }
    const userAuth = useAppSelector(state => state.authenticationReducer)
    const dispatch = useAppDispatch()

    const loginHandle:SubmitHandler<Users> = (data) => {
        dispatch(autheticateUser({
            "email": `${data.email}`,
            "password": `${data.password}`
        }))
    }

    useEffect(() => {
        if (userAuth.isAuthenticated) {
            routeChange()
        }
    },)

    return (
        <Grid item md={4} sx={{
            height: '100%',
            marginTop: '10%',
            marginBottom: '10%',
            width: '100%',
            display: 'flex',
            justifyContent: 'center',
            flexDirection: 'column',
            alignItems: 'center',
        }}>
            <Stack spacing={2} padding='20px' sx={{ width: '500px', border: '2px solid grey' }}>
                <Typography align='center' variant='h4' >LOG IN  </Typography>
                {/* <Typography>{userAuth.isError ? '' : 'Login Failed'}</Typography>  */}
                {/* <Typography>{loginStatus}</Typography> */}
                <TextField {...register('email')} variant='outlined' label='E-mail'  placeholder='Email Address' type='email' required></TextField>
                <Typography>{errors.email?.message}</Typography>
                <TextField {...register('password')} variant='outlined' label='Password' placeholder='Password' type='password'  required></TextField>
                <Typography>{errors.password?.message}</Typography>
                <FormControlLabel control={<Checkbox defaultChecked color='success' />} label="Remember Me" />
                <Button onClick={handleSubmit(loginHandle)} sx={{bgcolor:'#FFC108'}} variant='contained'>Login</Button>
                <Typography variant='body2' >Forgot Password?<Link to='/signup'> Click here</Link></Typography>
                <Divider />
                <Typography variant='body2' >Not registered? <Link to='/signup'>Sign-Up</Link></Typography>
            </Stack>
        </Grid>
    )
}

export default Login

