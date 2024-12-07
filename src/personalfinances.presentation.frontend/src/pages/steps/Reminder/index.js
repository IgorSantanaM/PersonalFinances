import React from 'react';
import {GrFormPrevious } from 'react-icons/gr';
import { GiWallet, } from "react-icons/gi";
import {Link} from 'react-router-dom'

import {Header, Title, IconWrapper} from '../Component/Header/styles';
import {Container} from './styles'

export default function StepReminder() {
  return (
    <>

      <Header>
      <Link to="/step/category" style={{ textDecoration: 'none' }}>
             <GrFormPrevious size={25} color="black" />
             <p>Previous</p>
          </Link>
         <IconWrapper>
            <GiWallet size={26} color="green" />
         </IconWrapper>
         <Title>Reminders</Title>
        </Header>
                
      <Container>

      </ Container>
    </>

  )
}
