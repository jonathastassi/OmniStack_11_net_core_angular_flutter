import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { OngsService } from 'src/app/services/ongs.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private service: OngsService,
    private router: Router
  ) {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(100)]],
      whatsapp: ['', [Validators.required, Validators.maxLength(30)]],
      city: ['', [Validators.required, Validators.maxLength(100)]],
      uf: ['', [Validators.required, Validators.maxLength(2)]]
    });
  }

  ngOnInit(): void {
  }

  handleRegister(): void {
    this.service.Post(this.form.getRawValue())
      .subscribe(data => {
        this.router.navigateByUrl('/');
        alert(`Seu ID de acesso: ${data.id}`);
      },
        err => {
          alert('Erro no cadastro, tente novamente!');
        });
  }

}
