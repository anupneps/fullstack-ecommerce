import { Link, useNavigate } from 'react-router-dom'
import { useAppSelector } from '../hooks/reduxHook';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import { AppBar, Box, CssBaseline, IconButton, ImageList, Toolbar, Typography, useTheme } from '@mui/material';
import { Avatar } from '@mui/material';
import Brightness4Icon from '@mui/icons-material/Brightness4';
import Brightness7Icon from '@mui/icons-material/Brightness7';
import React from 'react';
import { ColorModeContext } from './ChangeTheme';

const link = {
    textDecoration: "none",
    color: '#1a5db6',
    fontSize: "16px",
    marginLeft: '50px',
    fontWeight: 'bold'
}

 interface Iprops{
    title:string
}

const Navbar = ({title}:Iprops) => {
    const userInfo = useAppSelector(state => state.authenticationReducer)
    const cartItem = useAppSelector(state => state.cartReducer.cart)
    let navigate = useNavigate();
    const routeChange = () => {
        navigate('/');
    }
    const theme = useTheme();
    const colorMode = React.useContext(ColorModeContext);

    return (
        <AppBar  position='static' sx={{ height: '80px', alignContent: 'center', backgroundColor: "transparent" }}  >
            <CssBaseline />
            <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
                <ImageList sx={{ cursor: 'pointer' }}>
                    {theme.palette.mode === 'light' ?
                        <img onClick={routeChange} style={{ height: '60px' }} src={require('../images/logoWhite.PNG')} alt="" /> :
                        <img onClick={routeChange} style={{ height: '60px' }} src={require('../images/logo.PNG')} alt="" />
                    }
                </ImageList>
                <Typography variant='body1' sx={{ color: '#1a5db6' }}>
                    {userInfo.isAuthenticated ? 'Hello ' + userInfo.user?.userName : ' '}
                </Typography>

                <Box mt={2} marginRight={2} sx={{ color: 'red', display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
                    <Box
                        sx={{
                            display: 'flex',
                            alignItems: 'center',
                            justifyContent: 'center',
                            bgcolor: 'background.default',
                            color: 'text.primary',
                            borderRadius: 1,
                        }}
                    >
                        <IconButton sx={{ ml: 1 }} onClick={colorMode.toggleColorMode} color="inherit">
                            {theme.palette.mode === 'dark' ? <Brightness7Icon /> : <Brightness4Icon />}
                        </IconButton>
                    </Box>

                    <Link style={link} to="/" >Home</Link>
                    <Link style={link} to="/about" >About</Link>
                    <Link style={link} to="/categories" >Categories</Link>
                    {userInfo.user?.role === 'admin' ? <Link style={link} to="/admin" >Admin</Link> : ''}
                    <Link style={link} to="/cart"><ShoppingCartIcon sx={{ position: 'relative', top: 3, fontSize: '24px' }} />
                        <span style={{
                            position: 'absolute', color: '#ffffff', top: 25, fontSize: '14px', textAlign: 'center',
                            borderRadius: '50%', paddingLeft: '2px', paddingRight: '2px', width: '20px', backgroundColor: '#FFC108',
                            visibility: cartItem.length !== 0 ? 'visible' : 'hidden'
                        }}>{cartItem.length}</span></Link>
                    {userInfo.isAuthenticated ? <Link style={link} to="/profile" ><Avatar alt="User Profile" src={userInfo?.user?.avatar} /></Link> :
                        <Link style={link} to="/login" ><Avatar alt="User Profile" src={userInfo?.user?.avatar} />
                            <Typography variant='body2' fontWeight={'bold'} >Login</Typography></Link>
                    }
                </Box>
            </Toolbar>
        </AppBar>

    )
};

export default Navbar;