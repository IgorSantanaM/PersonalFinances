import React from 'react';
import {GrFormPrevious } from 'react-icons/gr';
import { GiWallet, } from "react-icons/gi";
import { FaCalendarAlt } from "react-icons/fa";
import { LuCalendarClock } from "react-icons/lu";

import {Header, Title, IconWrapper, Previous} from '../Component/Header/styles';
import { Container, StepButton} from '../Component/Container/styles';

export default function StepReminder() {
  return (
    <>

      <Header>
      <Previous to="/step/category">
             <GrFormPrevious size={25} color="black" />
             <p>Previous</p>
          </Previous>
        <div>
          <IconWrapper>
              <GiWallet size={26} color="green" />
          </IconWrapper>
         <Title>Reminders</Title>
         </div>

        </Header>
                
        <Container>
          <p>To set reminders, the most convenient way is to do it directly on the calendar. It is as easy as selecting the day in the calendar and pressing the "+" button at the bottom of the calendar</p>

          <StepButton to="/calendar">
            <button><FaCalendarAlt size={26} color="black"  /> <strong> Calendar</strong> </button>
            <p>Click here to go to the calendar.</p>
          </StepButton>

          <StepButton to="/reminders">
            <button><LuCalendarClock size={26} color="black"  /> <strong> Reminders </strong> </button>
            <p>If you prefer, you can also set them on the reminder page.</p>
          </StepButton>
          <strong>That's it! You can start recording your movements and keeping your accounts up to date with Homeasy. </strong> 
          <br/>
          <strong>We hope you find Homeasy useful in organizing your accounts!</strong>
      </ Container>
    </>

  )
}
