import React from 'react';
import {TfiCalendar, TfiClip} from 'react-icons/tfi';
import { MdMoreHoriz, MdNavigateNext, MdAccountBalance } from "react-icons/md";
import { GiWallet, GiTwoCoins } from "react-icons/gi";
import {Link} from 'react-router-dom'

import {Header, Title, IconWrapper} from '../Component/Header/styles';
import {Container}from './styles'

export default function Home(){

    return(
        <>
            <Header>
                <IconWrapper>
                    <GiWallet size={26} color="green" />
                </IconWrapper>
                <Title>Welcome to Homeasy</Title>
                <Link to="/step/account" style={{ textDecoration: 'none' }}>
                    <MdNavigateNext size={25} color="black" />
                    <p>Next</p>
                </Link>

            </Header>

            <Container>
                <p>Your tool to control all your accounts independently, with an optimised menu to visualise your data</p>
                
                <div>
                    <MdAccountBalance size={20} color="black"/>

                    <Link to="/balance" style={{ textDecoration: 'none' }}>
                     <strong >Balances</strong>
                    </Link>
                    
                    <p>The balance of all youraccounts at a glance!</p>
                </div>
                
                <div>
                    <TfiClip size={20} color="black"/>
                    
                    <Link to="/summary" style={{ textDecoration: 'none' }}>
                        <strong>Summary</strong>
                    </Link>

                    <p>Here you can see a basic report of movements and budgets for the selected month.</p>
                </div>
                
                <div>
                    <TfiCalendar size={20} color="black"/>

                    <Link to="/calendar" style={{ textDecoration: 'none' }}>
                        <strong>Calendar</strong>
                    </Link>

                    <p>A calendar to view payment reminders of each account.</p>
                </div>
                
                <div>
                    <GiTwoCoins size={20} color="black"/>

                    <Link to="/movement" style={{ textDecoration: 'none' }}>
                        <strong>Movements</strong>
                    </Link>

                    <p>List of all movements for the month for each account.</p>
                </div>
                
                <div>
                    <MdMoreHoriz size={20} color="black"/>

                    <Link to="/menu" style={{ textDecoration: 'none' }}>
                        <strong>More</strong>
                    </Link>

                    <p>Easy access to the management of all your data, tools and settings</p>
                </div>

                {/* TODO: ADD THE SYNC BUTTON */}
                <h4>Click the Next button as soon as your ready to set up your Homeasy accounts, it will only take a few minutes.</h4>
            </Container>
        </>
    )
}