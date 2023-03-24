import { Avatar, Paper, Table, TableContainer } from '@mui/material'
import Button from '@mui/material/Button'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableHead from '@mui/material/TableHead'
import TableRow from '@mui/material/TableRow'
import { useNavigate } from 'react-router-dom'
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'

import { logout } from '../redux/reducers/authenticationReducer'
import { emptyCart } from '../redux/reducers/cartReducer'

const Profile = () => {
    const dispatch = useAppDispatch()
    const userInfo = useAppSelector(state => state.authenticationReducer)
    const cartItem = useAppSelector(state => state.cartReducer.cart)
    let navigate = useNavigate();
    const routeChange = () => {
        navigate('/')
    }

    const handleLogout = () => {
        dispatch(logout())
        dispatch(emptyCart(cartItem))
        routeChange()
    }

    return (
        <TableContainer component={Paper}
            sx={{
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                margin: '50px',
                marginLeft: '40%',
                width: '30vw'
            }} >
            <Avatar alt="random" src={userInfo?.user?.avatar}
                sx={{ width: '200px', height: '200px', border: '1px solid black', margin: '10px' }} />
            <Table >
                <TableHead  >
                    <TableRow  >
                        <TableCell variant='head' sx={{ fontSize: '20px' }}>Profile Summary</TableCell>
                        <TableCell style={{ border: 'none' }} variant='head'>
                            <Button variant='contained' color='primary' >Edit</Button>
                        </TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell></TableCell>
                        <TableCell></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    <TableRow>
                        <TableCell>
                            {'First Name'}
                        </TableCell>
                        <TableCell>
                            {userInfo?.user?.firstName}
                        </TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>
                            {'Last Name'}
                        </TableCell>
                        <TableCell>
                            {userInfo?.user?.lastName}
                        </TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>
                            {'User Name'}
                        </TableCell>
                        <TableCell>
                            {userInfo?.user?.userName}
                        </TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>
                            {'Email'}
                        </TableCell>
                        <TableCell>
                            {userInfo?.user?.email}
                        </TableCell>
                    </TableRow>
                </TableBody>
            </Table>
            <Button onClick={handleLogout} variant='contained' color='primary' sx={{ margin: '20px' }} >LogOut</Button>
        </TableContainer>

    )
}

export default Profile


