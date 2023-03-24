import { Box, Card, CardMedia } from '@mui/material'

export const About = () => {
    return (
        <Box height={'fit-content'}>
            <Card>
                <CardMedia
                    sx={{ height: 850, width: 1050, margin: '10%' }}
                    image={require('../images/about.png')}
                />
            </Card>
        </Box>
    )
}
