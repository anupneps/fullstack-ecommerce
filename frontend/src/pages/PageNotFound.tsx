import { Box, Button, Typography } from '@mui/material'
import { useNavigate } from 'react-router-dom'

const PageNotFound = () => {
    const navigate = useNavigate()
    const reRoute = () => {
        navigate('/')
    }
    return (
        <Box
            sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'column',
                padding: '20px',
                marginTop: '14em'
            }}
        >
            <Typography variant="h1" style={{ color: '#1a5db6' }}>
                404
            </Typography>
            <Typography variant="h6" style={{ color: '#1a5db6' }}>
                This page doesnot exist !
            </Typography>
            <Button onClick={reRoute} variant="contained" sx={{ marginTop: '20px', backgroundColor: '#ffc108' }}>Back To Home</Button>
        </Box>
    )
}

export default PageNotFound