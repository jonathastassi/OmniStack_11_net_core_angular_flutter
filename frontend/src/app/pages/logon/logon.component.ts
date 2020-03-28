import { SessionsService } from './../../services/sessions.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logon',
  templateUrl: './logon.component.html',
  styleUrls: ['./logon.component.css']
})
export class LogonComponent implements OnInit {

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private service: SessionsService,
    private router: Router
  ) {
    this.form = this.fb.group({
      id: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  handleLogon() {
    this.service.Login(this.form.getRawValue())
      .subscribe(data => {
        this.router.navigateByUrl('/profile');
      },
        err => {
          alert('Erro no logon, tente novamente!');
        });
  }

}
